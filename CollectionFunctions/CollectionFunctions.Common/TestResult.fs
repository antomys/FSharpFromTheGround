namespace CollectionFunctions.Common

type TestResult =
    | Absent
    | Excused
    | Voided
    | Scored of float
    
module TestResult =
    
    let fromString (inputString : string) =
        if inputString = "A" then
            Absent
        elif inputString = "E" then
            Excused
        elif inputString = "V" then
            Voided
        else
            inputString
            |> float
            |> Scored
            
    let effectiveScore (testResult : TestResult) =
        match testResult with
        | Absent -> 0.0
        | Scored score -> score
        | Excused
        | _ -> 50.0
    
    let tryEffectiveScoreV2 (testResult : TestResult) =
        match testResult with
        | Absent -> 0.0 |> Some
        | Scored score -> score |> Some
        | Excused 
        | _ -> None
    
    let tryEffectiveScoreV2Custom (testResult : TestResult) =
        match testResult with
        | Absent -> 0.0 |> Something
        | Scored score -> score |> Something
        | Excused 
        | _ -> Nothing        