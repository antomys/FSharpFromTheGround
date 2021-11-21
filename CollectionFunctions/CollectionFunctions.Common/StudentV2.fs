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