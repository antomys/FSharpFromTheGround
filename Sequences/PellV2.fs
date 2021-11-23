namespace Sequences

type PellV2 =
    {
        N : int 
        Pn2 : int
        Pn1 : int
    }

module PellV2 =
    
    let pellV2 =
        { N = 0; Pn2 = 0; Pn1 = 0; }
        |> Seq.unfold (fun pellV2 ->
            let pn =
                match pellV2.N with
                | 0 | 1 -> pellV2.N
                | _ -> 2 * pellV2.Pn1 + pellV2.Pn2
            Some(pn, {N = pellV2.N + 1; Pn2 = pellV2.Pn1; Pn1 = pn;}))

    let startPellV2 =
        pellV2
        |> Seq.truncate 10
        |> Seq.iter (fun x -> printf $"{x},")
        
        printf "..."
        
        0