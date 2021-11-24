namespace CollectionFunctions.Common

type StudentV3 =
    {
        Name : string
        FirstName : string
        SchoolName : string
        StudentId : string
        MeanScore : float
        MinScore : float
        MaxScore : float
    }
    
module StudentV3 =
    
    open System.Collections.Generic
    
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
    let fromStringV4 (schoolCodes : IDictionary<int, string>) (inputString : string) =
        let studentElements = inputString.Split("\t")
        let studentName = studentElements.[0] |> namePartsAnonymous
        let schoolName = schoolCodes.[studentElements.[2] |> int]
        let mapped =
            studentElements
            |> Array.skip 3
            |> Array.map  TestResult.fromString
            // None will be completely away!
            |> Array.choose TestResult.tryEffectiveScoreV2
        
        {
            Name = studentName.Surname
            FirstName = studentName.FirstName
            SchoolName = schoolName
            StudentId = studentElements.[1]
            MeanScore = mapped |> Array.average
            MaxScore = mapped |> Array.max
            MinScore = mapped |> Array.min
        }
        
    let fromStringV4TryGet (schoolCodes : IDictionary<int, string>) (inputString : string) =
        let studentElements = inputString.Split("\t")
        let studentName = studentElements.[0] |> namePartsAnonymous
        let temp = studentElements.[2] |> int
        let schoolName =
            match schoolCodes.TryGetValue temp with
            |true, name -> name
            |false, _ -> "(Unknown)"
            
        let mapped =
            studentElements
            |> Array.skip 3
            |> Array.map  TestResult.fromString
            // None will be completely away!
            |> Array.choose TestResult.tryEffectiveScoreV2
        
        {
            Name = studentName.Surname
            FirstName = studentName.FirstName
            SchoolName = schoolName
            StudentId = studentElements.[1]
            MeanScore = mapped |> Array.average
            MaxScore = mapped |> Array.max
            MinScore = mapped |> Array.min
        }
        
    let fromStringV4Map (schoolCodes : Map<_, _>) (inputString : string) =
        let studentElements = inputString.Split("\t")
        let studentName = studentElements.[0] |> namePartsAnonymous
        let schoolName =
            schoolCodes
            |> Map.tryFind (studentElements.[2] |> int)
            |> Option.defaultValue "(Unknown)"
            
        let mapped =
            studentElements
            |> Array.skip 3
            |> Array.map  TestResult.fromString
            // None will be completely away!
            |> Array.choose TestResult.tryEffectiveScoreV2
        
        {
            Name = studentName.Surname
            FirstName = studentName.FirstName
            SchoolName = schoolName
            StudentId = studentElements.[1]
            MeanScore = mapped |> Array.average
            MaxScore = mapped |> Array.max
            MinScore = mapped |> Array.min
        }
        
    let fromStringV4MapGeneric (schoolCodes : Map<_, _>) (inputString : string) =
        let studentElements = inputString.Split("\t")
        let studentName = studentElements.[0] |> namePartsAnonymous
        let schoolName =
            schoolCodes
            |> Map.tryFind studentElements.[2]
            |> Option.defaultValue "(Unknown)"
            
        let mapped =
            studentElements
            |> Array.skip 3
            |> Array.map  TestResult.fromString
            // None will be completely away!
            |> Array.choose TestResult.tryEffectiveScoreV2

        {
            Name = studentName.Surname
            FirstName = studentName.FirstName
            SchoolName = schoolName
            StudentId = studentElements.[1]
            MeanScore = mapped |> Array.average
            MaxScore = mapped |> Array.max
            MinScore = mapped |> Array.min
        }