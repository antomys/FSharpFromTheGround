namespace CollectionFunctions

module Program =
    open System.IO
    let checkArgs (args:string[]) =
        args.Length <= 0

    let doesFileExist filePath =
        let isExist = File.Exists filePath
        
        if isExist then
            printfn $"File {filePath} exists! Proceeding." 
        else
            printfn $"File {filePath} not found"
        
        isExist

    [<EntryPoint>]
    let main args =
        if args |> checkArgs = false then
            printfn($"Processing file {args.[0]}")
            
            if doesFileExist args.[0] then

                let _ = args.[0]
                        |> File.ReadAllLines
                        |> Array.skip 1
                        |> Array.map Student.fromString
                        |> Array.sortBy (fun student -> student.Name)
                        |> Array.iter Student.printSummary
                0
            else
                0
        else
            printf("No args are assigned. Exit.")
            0
            
            
            
                            // v1 version
                (*let studentRows = args.[0]
                                  |> File.ReadAllLines
                                  |> Array.skip 1
               
                for studentRow in studentRows do
                     studentRow
                     |> Student.fromString
                     |> Student.printSummary*)
                     