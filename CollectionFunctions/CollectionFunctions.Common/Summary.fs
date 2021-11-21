namespace CollectionFunctions.Common

module Summary =
    let printSummaryV2 (student : StudentV2) =
        printfn $"Student {student.Name}; Mean : {student.MeanScore}; Max : {student.MaxScore}; Min : {student.MinScore}"
        
    let printSummaryV1 (student : Student) =
        printfn $"Student {student.Name}; Mean : {student.MeanScore}; Max : {student.MaxScore}; Min : {student.MinScore}"
