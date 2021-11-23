namespace Sequences

module Pell =
    
    let pell =
        (0,0,0)
        |> Seq.unfold (fun (n, pn2, pn1) ->
            let pn =
                match n with
                |0 |1 -> n
                | _ -> 2 * pn1 + pn2
            let n' = n + 1
            Some(pn, (n', pn1, pn)))

    let startPell =
        pell
        |> Seq.truncate 10
        |> Seq.iter (fun x -> printf $"{x},")
        
        printf "..."
        
        0