// Define the list of names
let names = ["James"; "Robert"; "John"; "William"; "Michael"; "David"; "Richard"]

// Filter names containing the letter "i" (case-sensitive)
let filteredNames = names |> List.filter (fun s -> s.Contains("i"))

// Concatenate the filtered names
let combined = filteredNames |> List.reduce (+)

// Print the original list of names
printfn "Original names:"
names |> List.iter (printfn "%s")

// Print the filtered names
printfn "\nNames containing 'i':"
filteredNames |> List.iter (printfn "%s")

// Print the combined result
printfn "\nCombined names: %s" combined

// Verify the result
let expectedResult = "WilliamMichaelRichard"
printfn "\nDoes the result match the expected output? %b" (combined = expectedResult)
