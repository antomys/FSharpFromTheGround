namespace CollectionFunctions.Common

type StudentV2 =
    {
        Name : string
        FirstName : string
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
    let namePartsVanilla (inputString : string) =
        let elements = inputString.Split ','
        
        match elements with
        | [|surname; firstName|] ->
            surname.Trim(), firstName.Trim()
        | [|surname|] ->
            surname.Trim(), None |> string
        | _ ->
            raise (System.FormatException $"Invalid format exception for {inputString}")
            
    let namePartsAnonymous (inputString : string) =
        let elements = inputString.Split ','
        
        match elements with
        | [|surname; firstName|] ->
            {|Surname = surname; FirstName = firstName |}
        | [|surname|] ->
            {|Surname = surname; FirstName = None |> string |}
        | _ ->
            raise (System.FormatException $"Invalid format exception for {inputString}")
    
    let fromString (inputString : string) =
        let studentElements = inputString.Split("\t")
        let studentName = studentElements.[0] |> namePartsVanilla
        let mapped =
            studentElements
            |> Array.skip 2
            |> Array.map  (Float.fromStringOr50V3 50.0)
        
        {
            Name = fst studentName
            FirstName = snd studentName
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
            FirstName = ""
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
        let studentName = studentElements.[0] |> namePartsAnonymous
        let mapped =
            studentElements
            |> Array.skip 2
            |> Array.map  TestResult.fromString
            // None will be completely away!
            |> Array.choose TestResult.tryEffectiveScoreV2
        
        {
            Name = studentName.Surname
            FirstName = studentName.FirstName
            StudentId = studentElements.[1]
            MeanScore = mapped |> Array.average
            MaxScore = mapped |> Array.max
            MinScore = mapped |> Array.min
        }       