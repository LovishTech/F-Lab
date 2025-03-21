// Define a power function using integer exponents
let power exponent value = pown value exponent

// Create specialized functions using partial application
let square = power 2  // Function to calculate the square of a number
let cube = power 3    // Function to calculate the cube of a number

// Example usage of the square and cube functions
printfn "Square of 5: %d" (square 5)   // 25
printfn "Cube of 4: %d" (cube 4)       // 64

// Additional examples to demonstrate usage
let examples = [1; 2; 3; 4; 5]

printfn "\nSquares of numbers from the list:"
examples |> List.iter (fun x -> printfn "Square of %d: %d" x (square x))

printfn "\nCubes of numbers from the list:"
examples |> List.iter (fun x -> printfn "Cube of %d: %d" x (cube x))

// Verify results for specific cases
let verifySquare = square 6   // Expected: 36
let verifyCube = cube 3       // Expected: 27

printfn "\nVerification:"
printfn "Square of 6: %d (Expected: 36)" verifySquare
printfn "Cube of 3: %d (Expected: 27)" verifyCube

// Demonstrate that the functions are reusable
let fourthPower = power 4    // Function to calculate the fourth power of a number
printfn "\nFourth power of 2: %d" (fourthPower 2)   // Expected: 16
