open CollectionFunctions.Common

module CollectionFunctionsAe =

    [<EntryPoint>]
    let main args =
        if args.Length <= 0 then
            printfn "Arguments are obsolete. Exit"
            0
        else
            let fileLines =
                args.[0]
                |> FileService.tryOpenRead
                |> FileService.filterNone
            
            if fileLines.Length = 0 then
                printfn "Error reading. Exit"
                0
            else
                let _ =fileLines
                    |> Array.map StudentV2.fromStringV2
                    |> Array.sortBy (fun student -> student.Name)
                    |> Array.iter Summary.printSummaryV2
                
                printfn "--------------------------------"
                
                let _ =fileLines
                    |> Array.map StudentV2.fromStringV4
                    |> Array.sortBy (fun student -> student.Name)
                    |> Array.iter Summary.printSummaryV2
                0
               