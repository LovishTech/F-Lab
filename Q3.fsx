// Function to calculate the product of odd numbers from n down to 1
let productOdds n =
    let rec loop acc current =
        if current < 1 then acc
        else loop (acc * current) (current - 2)
    loop 1 n

// Example usage
let n = 11
let result = productOdds n

// Print the result
printfn "Product of odd numbers from %d to 1: %d" n result

// Additional examples for verification
let testCases = [1; 3; 5; 7; 9; 11; 13]

printfn "\nAdditional test cases:"
testCases
|> List.iter (fun x -> 
    printfn "Product of odd numbers from %d to 1: %d" x (productOdds x))

// Verify a specific case
let verifyCase = 11
let expectedResult = 10395
let actualResult = productOdds verifyCase
printfn "\nVerification for n = %d:" verifyCase
printfn "Expected result: %d" expectedResult
printfn "Actual result: %d" actualResult
printfn "Correct? %b" (expectedResult = actualResult)
