
[<EntryPoint>]
let main argv =
    for i in 0..argv.Length-1 do
        let person = argv.[i]
        printfn $"{person}"
    printfn "Hello f#"
    0