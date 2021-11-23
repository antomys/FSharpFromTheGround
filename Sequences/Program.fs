namespace Sequences

open System
open System.IO
open CollectionFunctions.Common

module Program =
    // Define a function to construct a message to print
    let from whom =
        $"from %s{whom}"

    //let declares (binds) a value or function)
    [<EntryPoint>]
    let main args =
        
        
        printfn "PELLV2"
        let _ = PellV2.startPellV2
        
        0
        (*let squareSumV2 =
            Seq.initInfinite (fun index ->
                let x = index + 1
                pown x 2 )
            |> Seq.truncate 1000
            |> Seq.sum
       
        printfn $"Seq Infinite : {squareSumV2}"     
            
        let total =
            seq {for i in 1..1000 -> pown i 2}
            |> Seq.sum
        
        printfn $"{total}"
        
        let bricks =
                seq {
                    (3, 2, ConsoleColor.Yellow)
                    (4, 2, ConsoleColor.Green)
                    (2, 1, ConsoleColor.Magenta)
                    (1, 1, ConsoleColor.Blue)
                    (2, 2, ConsoleColor.Red)
                    (4, 2, ConsoleColor.Blue)
                    (4, 2, ConsoleColor.Magenta)
                    (2, 2, ConsoleColor.Magenta)
                    (2, 2, ConsoleColor.Red)
                    (4, 2, ConsoleColor.Blue)
                    (3, 2, ConsoleColor.Magenta)
                    (4, 2, ConsoleColor.Green)
                    (3, 2, ConsoleColor.Red)
                    (4, 1, ConsoleColor.Blue)
                    (4, 2, ConsoleColor.Yellow)
                    (4, 2, ConsoleColor.Yellow)
                    (1, 1, ConsoleColor.Blue)
                    (1, 1, ConsoleColor.Green)
                    (2, 1, ConsoleColor.Yellow)
                    (4, 1, ConsoleColor.Magenta)
                }
                |> Seq.map (fun (sc, sr, cc) -> { StudColumns = sc; StudRows = sr; Color = cc })

        printfn "All the bricks:"
        bricks
        |> Seq.iter Brick.printConsole
        printfn "\n"
        
        printfn "PELL"
        let _ = Pell.startPell
        
        printfn "PELLV2"
        let _ = PellV2.startPellV2
        
        if args |> FileService.checkArgs = false then
            printfn($"Processing file {args.[0]}")
            
            if FileService.doesFileExist args.[0] then

                let _ = args.[0]
                        |> File.ReadLines
                        |> Seq.cache
                        |> Seq.skip 1
                        |> Seq.map Student.fromString
                        |> Seq.sortBy (fun student -> student.Name)
                        |> Seq.iter Summary.printSummaryV1
                0
            else
                0
        else
            printf("No args are assigned. Exit.")
            0*)