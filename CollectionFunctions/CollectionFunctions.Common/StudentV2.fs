namespace CollectionFunctions.Common

type StudentV2 =
    {
        Name : string
        StudentId : string
        MeanScore : float
        MinScore : float
        MaxScore : float
    }
    
module StudentV2 =
    let getStudentsCount (studentFile:string[]) =
        studentFile |> Array.length
    
    let fromString (inputString : string) =
        let studentElements = inputString.Split("\t")
        let mapped =
            studentElements
            |> Array.skip 2
            |> Array.map  (Float.fromStringOr50V3 50.0)
        
        {
            Name = studentElements.[0]
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
        let mapped =
            studentElements
            |> Array.skip 2
            |> Array.map  TestResult.fromString
            // None will be completely away!
            |> Array.choose TestResult.tryEffectiveScoreV2
        
        {
            Name = studentElements.[0]
            StudentId = studentElements.[1]
            MeanScore = mapped |> Array.average
            MaxScore = mapped |> Array.max
            MinScore = mapped |> Array.min
        }       