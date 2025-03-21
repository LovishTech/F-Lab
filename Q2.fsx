// Function to calculate the product of all elements in a list
let productList items =
    let rec loop acc = function
        | [] -> acc
        | head::tail -> loop (acc * head) tail
    loop 1 items

// Example usage
printfn "Product of [2; 3; 4]: %d" (productList [2; 3; 4])  // 24

// Additional test cases
let testCases = [
    []              // Empty list
    [1]             // Single element
    [1; 2; 3; 4; 5] // Multiple elements
    [10; 20; 30]    // Larger numbers
    [0; 1; 2; 3]    // List with zero
]

// Function to print the result for each test case
let printResult case =
    let result = productList case
    printfn "Product of %A: %d" case result

// Print results for all test cases
printfn "\nAdditional test cases:"
List.iter printResult testCases

// Verify a specific case
let verifyCase = [2; 3; 4]
let expectedResult = 24
let actualResult = productList verifyCase
printfn "\nVerification for %A:" verifyCase
printfn "Expected result: %d" expectedResult
printfn "Actual result: %d" actualResult
printfn "Correct? %b" (expectedResult = actualResult)
