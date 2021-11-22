namespace CollectionFunctions.Common

type StudentV2 =
    {
        Name : string
        SurName : string
        StudentId : string
        MeanScore : float
        MinScore : float
        MaxScore : float
    }
    
module StudentV2 =
    let getStudentsCount (studentFile:string[]) =
        studentFile |> Array.length
    
    let namePartsVMinus1 (inputString : string) =
        let elements = inputString.Split ','
        
        elements.[0].Trim(), elements.[1].Trim()
    let nameParts (inputString : string) =
        let elements = inputString.Split ','
        
        match elements with
        | [|surname; firstName|] ->
            surname.Trim(), firstName.Trim()
        | _ ->
            raise (System.FormatException $"Invalid format exception for {inputString}")
            
    
    
    let fromString (inputString : string) =
        let studentElements = inputString.Split("\t")
        let studentName = studentElements.[0] |> nameParts
        let mapped =
            studentElements
            |> Array.skip 2
            |> Array.map  (Float.fromStringOr50V3 50.0)
        
        {
            Name = fst studentName
            SurName = snd studentName
            StudentId = studentElements.[1]
            MeanScore = mapped |> Array.average
            MaxScore = mapped |> Array.max
            MinScore = mapped |> Array.min
        }
    
    let fromStringV2 (inputString : string) =
        let studentElements = inputString.Split("\t")
        let mapped =
            studentElements
            |> Array.skip 2
            |> Array.map  TestResult.fromString
            |> Array.map TestResult.effectiveScore
        
        {
            Name = studentElements.[0]
            SurName = ""
            StudentId = studentElements.[1]
            MeanScore = mapped |> Array.average
            MaxScore = mapped |> Array.max
            MinScore = mapped |> Array.min
        }
        
    let fromStringV3 (inputString : string) =
        let studentElements = inputString.Split("\t")
        let mapped =
            studentElements
            |> Array.skip 2
            |> Array.map  TestResult.fromString
            |> Array.map TestResult.tryEffectiveScoreV2
            |> Array.filter Option.isSome
            |> Array.map Option.get
        
        {
            Name = studentElements.[0]
            StudentId = studentElements.[1]
            MeanScore = mapped |> Array.average
            MaxScore = mapped |> Array.max
            MinScore = mapped |> Array.min
        }
        
    let fromStringV4 (inputString : string) =
        let studentElements = inputString.Split("\t")
        let studentName = studentElements.[0] |> nameParts
        let mapped =
            studentElements
            |> Array.skip 2
            |> Array.map  TestResult.fromString
            // None will be completely away!
            |> Array.choose TestResult.tryEffectiveScoreV2
        
        {
            Name = fst studentName
            SurName = snd studentName
            StudentId = studentElements.[1]
            MeanScore = mapped |> Array.average
            MaxScore = mapped |> Array.max
            MinScore = mapped |> Array.min
        }       