namespace AvaloniaApplication5

open System
open Avalonia
open Avalonia.Controls
open Avalonia.Interactivity
open Avalonia.Markup.Xaml

type MainWindow () as this = 
    inherit Window ()
    
    let mutable displayText = ""
    let mutable firstNumber = 0.0
    let mutable operation = ""
    let mutable isNewOperation = true
    
    // UI elements references
    let mutable displayTextBlock : TextBlock = null
    
    do this.InitializeComponent()
        
    member private this.InitializeComponent() =
#if DEBUG
        this.AttachDevTools()
#endif
        AvaloniaXamlLoader.Load(this)
        
        // Get references to UI elements
        displayTextBlock <- this.FindControl<TextBlock>("DisplayText")
        
        // Connect event handlers for number buttons
        for i in 0..9 do
            let button = this.FindControl<Button>(sprintf "Button%d" i)
            button.Click.AddHandler(fun _ _ -> this.NumberButton_Click(string i))
        
        // Connect event handlers for operation buttons
        this.FindControl<Button>("ButtonPlus").Click.AddHandler(fun _ _ -> this.OperationButton_Click("+"))
        this.FindControl<Button>("ButtonMinus").Click.AddHandler(fun _ _ -> this.OperationButton_Click("-"))
        this.FindControl<Button>("ButtonMultiply").Click.AddHandler(fun _ _ -> this.OperationButton_Click("*"))
        this.FindControl<Button>("ButtonDivide").Click.AddHandler(fun _ _ -> this.OperationButton_Click("/"))
        this.FindControl<Button>("ButtonEquals").Click.AddHandler(fun _ _ -> this.EqualsButton_Click())
        this.FindControl<Button>("ButtonClear").Click.AddHandler(fun _ _ -> this.ClearButton_Click())
        this.FindControl<Button>("ButtonDecimal").Click.AddHandler(fun _ _ -> this.DecimalButton_Click())
        
        // Initialize display
        displayTextBlock.Text <- "0"
    
    member private this.NumberButton_Click(number: string) =
        if isNewOperation then
            displayText <- number
            isNewOperation <- false
        else
            displayText <- displayText + number
        
        displayTextBlock.Text <- displayText
    
    member private this.OperationButton_Click(op: string) =
        try
            firstNumber <- Double.Parse(displayText)
            operation <- op
            isNewOperation <- true
        with
        | _ -> ()
    
    member private this.EqualsButton_Click() =
        try
            let secondNumber = Double.Parse(displayText)
            let result =
                match operation with
                | "+" -> firstNumber + secondNumber
                | "-" -> firstNumber - secondNumber
                | "*" -> firstNumber * secondNumber
                | "/" -> 
                    if secondNumber = 0.0 then
                        raise (DivideByZeroException())
                    else
                        firstNumber / secondNumber
                | _ -> secondNumber
            
            displayText <- result.ToString()
            displayTextBlock.Text <- displayText
            isNewOperation <- true
        with
        | :? DivideByZeroException -> 
            displayTextBlock.Text <- "Error: Division by zero"
            isNewOperation <- true
        | _ -> 
            displayTextBlock.Text <- "Error"
            isNewOperation <- true
    
    member private this.ClearButton_Click() =
        displayText <- ""
        firstNumber <- 0.0
        operation <- ""
        isNewOperation <- true
        displayTextBlock.Text <- "0"
    
    member private this.DecimalButton_Click() =
        if isNewOperation then
            displayText <- "0."
            isNewOperation <- false
        elif not (displayText.Contains(".")) then
            displayText <- displayText + "."
        
        displayTextBlock.Text <- displayText