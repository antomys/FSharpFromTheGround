namespace Lookups

module SchoolCodes =
    
    open System.IO
    open System.Collections.Generic
    
    let load (filePath : string) =
        File.ReadAllLines filePath
        |> Seq.skip 1
        |> Seq.map (fun row ->
            let elements = row.Split("\t")
            let id = elements.[0] |> int
            let name = elements.[1]
            
            id, name)

    let loadDictionaryV1 (filePath : string) =
        Dictionary<int, string>
            (
                File.ReadAllLines filePath
                |> Seq.skip 1
                |> Seq.map (fun row ->
                    let elements = row.Split("\t")
                    let id = elements.[0] |> int
                    let name = elements.[1]
                    
                    KeyValuePair.Create(id, name))
            )
    
    let loadDictionarySimple (filePath : string) =
        File.ReadAllLines filePath
        |> Seq.skip 1
        |> Seq.map (fun row ->
            let elements = row.Split("\t")
            let id = elements.[0] |> int
            let name = elements.[1]
            
            id, name)
        |> dict
        
    let loadMap (filePath : string) =
        File.ReadAllLines filePath
        |> Seq.skip 1
        |> Seq.map (fun row ->
            let elements = row.Split("\t")
            let id = elements.[0] |> int
            let name = elements.[1]
            
            id, name)
        |> Map.ofSeq
        
    let loadMapV2 (filePath : string) =
        File.ReadAllLines filePath
        |> Seq.skip 1
        |> Seq.map (fun row ->
            let elements = row.Split("\t")
            let id = elements.[0]
            let name = elements.[1]
            
            id, name)
        |> Map.ofSeq