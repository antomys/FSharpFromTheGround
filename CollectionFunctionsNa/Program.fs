namespace CollectionFunctionsNa

open System.IO
open CollectionFunctions.Common

module Program =
     
     [<EntryPoint>]
     let main args =
            if args |> FileService.checkArgs = false then
                printfn($"Processing file {args.[0]}")
                
                if FileService.doesFileExist args.[0] then

                    let _ = args.[0]
                            |> File.ReadAllLines
                            |> Array.skip 1
                            |> Array.map StudentV2.fromString
                            |> Array.sortBy (fun student -> student.Name)
                            |> Array.iter Summary.printSummaryV2
                    0
                else
                    0
            else
                printf("No args are assigned. Exit.")
                0