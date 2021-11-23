namespace GenericPoints

open GenericPoints

module Program =

    [<EntryPoint>]
    let main _ =
        
        let pFloat1 = { X = 1.0; Y = 2.0 } : Point
        let pFloat2 = pFloat1
                      |> Point.moveBy 3.0 4.0
                      
        printfn $"pFloat1 %A{pFloat1} pFloat2: %A{pFloat2}"
        
        let pFloat1 = { X = 1.0; Y = 2.0 } : GenericPoint<float>
        let pFloat2 = pFloat1
                      |> GenericPoint.moveBy 3.0 4.0
                      
        printfn $"pFloat1 %A{pFloat1} pFloat2: %A{pFloat2}"
        
        let pFloat1 = { X = "a"; Y = "b" } : GenericPoint<string>
        let pFloat2 = pFloat1
                      |> GenericPoint.moveBy "c" "d"
                      
        printfn $"pFloat1 %A{pFloat1} pFloat2: %A{pFloat2}"
        0