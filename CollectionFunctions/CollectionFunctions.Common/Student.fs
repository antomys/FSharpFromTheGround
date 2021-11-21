namespace CollectionFunctions.Common

type Student =
    {
        Name : string
        StudentId : string
        MeanScore : float
        MinScore : float
        MaxScore : float
    }
    
module Student =
    
    let printSummary (student : Student) =
        printfn $"Student {student.Name}; Mean : {student.MeanScore}; Max : {student.MaxScore}; Min : {student.MinScore}"
        
    let getStudentsCount (studentFile:string[]) =
        studentFile |> Array.length
    
    let getMeanScore (studentRow: string) =
        let studentElements = studentRow.Split("\t")
        let omitStringArray = studentElements |> Array.skip 2
        
        let mean =
            omitStringArray
            |> Array.map float
            |> Array.average
        
        let min =
            omitStringArray
            |> Array.minBy float
        let max =
            omitStringArray
            |> Array.maxBy float
            
        $"{studentElements.[0]}:{studentElements.[1]}:mean:{mean}:min:{min}:max:{max}"
    
    let getMeanScoreV2 (studentRow: string) =
        let studentElements = studentRow.Split("\t")
        let mapped =
            studentElements
            |> Array.skip 2
            |> Array.map float
        let mean = mapped |> Array.average
        let max = mapped |> Array.max
        let min = mapped |> Array.min

        $"{studentElements.[0]}:{studentElements.[1]}:mean:{mean}:min:{min}:max:{max}"
        
        
    let getMeanScoreV3 (studentRow: string) =
        let studentElements = studentRow.Split("\t")
        let mapped =
            studentElements
            |> Array.skip 2
            |> Array.map float
        
        let mean = mapped |> Array.average
        let tupleStack = (Array.max mapped, Array.min mapped)

        $"{studentElements.[0]}:{studentElements.[1]}:mean:{mean}:min:{snd tupleStack}:max:{fst tupleStack}"

    let fromString (inputString : string) =
        let studentElements = inputString.Split("\t")
        let mapped =
            studentElements
            |> Array.skip 2
            |> Array.map float
        
        {
            Name = studentElements.[0]
            StudentId = studentElements.[1]
            MeanScore = mapped |> Array.average
            MaxScore = mapped |> Array.max
            MinScore = mapped |> Array.min
        }