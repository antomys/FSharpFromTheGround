open System;    
    // for construction in fsharp
let forLoop (argv : string[])  =
    for i in 0..argv.Length-1 do
        let person = argv.[i]
        printfn $"{person}"
        
     // foreach loop
let foreachLoop (argv : string[])  =
     for variable in argv do
        printfn $"{variable}"

    
    // filter invalid input
let isValid inputString =
    String.IsNullOrWhiteSpace(inputString) |> not
    
    // Array.iter f# approach
let printOut stringInput =
    printfn $"{stringInput}"
    
let arrayIter (argv : string[]) =
    // Higher order functions
    // (a func that takes one or more functions as arguments)
    Array.iter printOut argv
    
    // Filtering firstly and then printing
let arrayIterV2 (argv : string[]) =
    // Higher order functions
    // (a func that takes one or more functions as arguments)
    argv
    |> Array.filter isValid
    |> Array.iter printOut
    

[<EntryPoint>]
let main argv =
    forLoop argv
    foreachLoop argv
    arrayIter argv
    arrayIterV2 argv
    printfn "Hello f#"
    0