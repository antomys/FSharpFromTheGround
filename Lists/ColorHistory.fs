namespace Lists

open System.Drawing

type ColorHistory (initialColors :seq<Color>, maxLength : int) =
    let mutable colors =
        initialColors
        |> Seq.truncate maxLength
        |> List.ofSeq
        
    member this.Colors() =
        colors |> Seq.ofList
        
    member this.Add(color : Color) =
        let colors' =
            color :: colors
            |> List.distinct
            |> List.truncate maxLength
        
        colors <- colors'
        
    member this.TryLatest() =
        match colors with
        | head :: _ -> head |> Some
        | [] -> None
        
    member this.ListColors() =
        colors
        |> Seq.iter (fun color -> printfn $"{color}")
        
    member this.RemoveLatest() =
        match colors with
        | _::tail -> colors <- tail   // The last element of a longer list is the last element of its tail
        | _ -> ()