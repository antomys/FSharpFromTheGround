namespace CollectionFunctions

open CollectionFunctions.Common

module Program =
    open System.IO
  
    [<EntryPoint>]
    let main args =
        if args |> FileService.checkArgs = false then
            printfn($"Processing file {args.[0]}")
            
            if FileService.doesFileExist args.[0] then

                let _ = args.[0]
                        |> File.ReadAllLines
                        |> Array.skip 1
                        |> Array.map Student.fromString
                        |> Array.sortBy (fun student -> student.Name)
                        |> Array.iter Summary.printSummaryV1
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
                     