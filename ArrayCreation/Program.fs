// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System.IO

let readBytes length (stream : Stream) =
    let buffer = Array.zeroCreate length
    let count = stream.Read(buffer,0,length)
    if count = length then
        buffer
    else
        raise <| EndOfStreamException "Exception.Ended stream."
        
let isEven x =
    x % 2 = 0
[<EntryPoint>]
let main _ =
    let numbers = [|1;2;3;4;5|]
    let numbersIter = [| for i in 0..4 -> pown 2 i |]
    let numbersEven =
        [|
           for i in 1..9 ->
               let x = i * i
               if x |> isEven then
                    x
               else
                    0
        |]
        
    let numbersEvenV2 =
        // Array comprehension.
        [|
           for i in 1..9 do
               let x = i * i
               if x |> isEven then
                    // implicit yield form.
                    x
        |]
    
    let squareSum =
        [|
            for i in 1..1000 do pown i 2
        |]
        |> Array.sum
    printfn $"{squareSum}"
    
    let squareSumV2 =
        Array.init 1000 (fun index ->
            let x = index + 1
            pown x 2 )
        |> Array.sum
        
    printfn $"{squareSumV2}"   
    
    let zeroArray = Array.zeroCreate<int> 10
    
    printfn $"ZeroArray : %A{zeroArray}"
        
    for i in 0..9 do
        zeroArray.[i] <- i
    
    printfn $"ZeroArray populated : %A{zeroArray}"
    0 // return an integer exit code