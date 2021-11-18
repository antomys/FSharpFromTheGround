    // for construction in fsharp
let forLoop (argv : string[])  =
    for i in 0..argv.Length-1 do
        let person = argv.[i]
        printfn $"{person}"
        
     // foreach loop
let foreachLoop (argv : string[])  =
     for variable in argv do
        printfn $"{variable}"

    // Array.iter f# approach
let printOut stringInput =
    printfn $"{stringInput}"
    
let arrayIter (argv : string[]) =
    Array.iter printOut argv
    

[<EntryPoint>]
let main argv =
    forLoop(argv)
    foreachLoop(argv)
    arrayIter(argv)
    printfn "Hello f#"
    0