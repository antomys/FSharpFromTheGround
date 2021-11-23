open CollectionFunctions.Common

module CollectionFunctionsAe =

    [<EntryPoint>]
    let main args =
        if args.Length <= 0 then
            printfn "Arguments are obsolete. Exit"
            0
        else
            try
                let fileLines =
                    args.[0]
                    |> FileService.tryOpenRead
                    |> FileService.filterNone

                if fileLines.Length = 0 then
                    printfn "Error reading. Exit"
                    0
                else
                    try
                        let _ =
                            fileLines
                            |> Array.map StudentV2.fromStringV2
                            |> Array.sortBy (fun student -> student.Name)
                            |> Array.iter Summary.printSummaryV2
                        
                        printfn "--------------------------------"
                        
                        let _ =
                            fileLines
                            |> Array.map StudentV2.fromStringV4
                            |> Array.sortBy (fun student -> student.Name)
                            |> Array.iter Summary.printSummaryV2
                        0
                    with
                    | :? System.FormatException as exn ->
                        printfn $"File is faulty! {exn.Message}"
                        1
                    | _ as exn ->
                        printf $"Unhandled exception! {exn.Message}"
                        1
            with
            | _ as exp ->
                printfn $"Error occured! {exp.Message}"
                1       