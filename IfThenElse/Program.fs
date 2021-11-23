let from whom =
    $"from {whom}"

[<EntryPoint>]
let main argv =
    let message = (from "F#") // Call the function
    let person = if argv.Length > 0 then argv.[0] else ""
        
    printfn $"Hello world {message}, {person}"
    0 // return an integer exit code