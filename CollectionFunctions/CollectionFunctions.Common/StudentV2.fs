namespace CollectionFunctions.Common

module Float=
    
    let tryFromString s =
        if s = "N/A" then
            None
        else
            float s |> Some
   
    let fromStringOr50 inputString =
        let result = inputString |> tryFromString
        
        if result = None then
            50.0
        else
            result.Value

    let fromStringOr50V3 floatDefault inputString =
        let result = inputString |> tryFromString
        
        if result = None then
            floatDefault
        else
            result.Value
    
    let fromStringOr50V2 inputString =
        inputString
        |> tryFromString
        |> Option.defaultValue 50.0
            

type StudentV2 =
    {
        Name : string
        StudentId : string
        MeanScore : float
        MinScore : float
        MaxScore : float
    }

module StudentV2 =
    
    let printSummary (student : StudentV2) =
        printfn $"Student {student.Name}; Mean : {student.MeanScore}; Max : {student.MaxScore}; Min : {student.MinScore}"
        
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