namespace CollectionFunctions

open CollectionFunctions.Common

module Students =
    
    open System.IO
  
    let runStudents args =
        if args |> FileService.checkArgs = false then
            printfn($"Processing file {args.[0]}")
            
            if FileService.doesFileExist args.[0] then

                let students =
                    args.[0]
                    |> File.ReadAllLines
                    |> Array.skip 1
                    |> Array.map StudentV2.fromString
                    |> Array.sortBy (fun student -> student.Name)
                  
                let _ = students
                        |> Array.groupBy (fun student -> student.Name)
                        |> Array.iter(fun (key,value) -> value |> Summary.printGroupSummary key )
                0
            else
                0
        else
            printf("No args are assigned. Exit.")
            0