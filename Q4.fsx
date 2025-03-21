// Define the list of names
let names = [" Charles"; "Babbage  "; "  Von Neumann  "; "  Dennis Ritchie  "]

// Trim the names using List.map
let trimmedNames = names |> List.map (fun s -> s.Trim())

// Print the original names
printfn "Original names:"
names |> List.iter (printfn "%s")

// Print the trimmed names
printfn "\nTrimmed names:"
trimmedNames |> List.iter (printfn "%s")

// Demonstrate that the result matches the expected output
let expectedOutput = ["Charles"; "Babbage"; "Von Neumann"; "Dennis Ritchie"]
printfn "\nDoes the result match the expected output? %b" (trimmedNames = expectedOutput)
