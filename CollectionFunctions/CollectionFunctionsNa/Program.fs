namespace CollectionFunctionsNa

open System.IO
open CollectionFunctions.Common

module Program =
     
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
                            |> Array.map StudentV2.fromString
                            |> Array.sortBy (fun student -> student.Name)
                            |> Array.iter StudentV2.printSummary
                    0
                else
                    0
            else
                printf("No args are assigned. Exit.")
                0