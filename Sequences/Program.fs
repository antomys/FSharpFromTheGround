namespace Sequences

open System

module Program =
    // Define a function to construct a message to print
    let from whom =
        $"from %s{whom}"

    //let declares (binds) a value or function)
    [<EntryPoint>]
    let main _ =
        
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
        0 // return an integer exit code