namespace CollectionFunctions.Common

open System.IO

module FileService =
    let checkArgs (args:string[]) =
        args.Length <= 0
     
    let doesFileExist filePath =
        let isExist = File.Exists filePath
        
        if isExist then
            printfn $"File {filePath} exists! Proceeding." 
        else
            printfn $"File {filePath} not found"
        
        isExist
        
    let tryOpenRead (filePath : string) =
        if File.Exists filePath then
            filePath
            |> File.ReadAllLines
            |> Array.skip(1)
            |> Some
        else
            None
    
    let filterNone (inputOptionString : string[] option) =
        match inputOptionString with
        | Some x -> x 
        | None -> null
