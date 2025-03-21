// Create a sequence of the first 700 positive integers
let sequence = seq { 1 .. 700 }

// Convert the sequence into a list
let numberList = Seq.toList sequence

// Filter out elements that are multiples of both 7 and 5
let filteredList = 
    numberList 
    |> List.filter (fun x -> x % 35 = 0)  // 35 is the LCM of 7 and 5

// Sum all the filtered numbers using fold
let sum = List.fold (+) 0 filteredList

// Print the results
printfn "Original sequence length: %d" (Seq.length sequence)
printfn "Filtered list: %A" filteredList
printfn "Sum of multiples of 35 up to 700: %d" sum

// Verification
let expectedSum = [35; 70; 105; 140; 175; 210; 245; 280; 315; 350; 385; 420; 455; 490; 525; 560; 595; 630; 665; 700] |> List.sum
printfn "\nVerification:"
printfn "Expected sum: %d" expectedSum
printfn "Calculated sum: %d" sum
printfn "Correct? %b" (expectedSum = sum)
