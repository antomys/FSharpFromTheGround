namespace CollectionFunctions.Common

module Summary =
    let printSummaryV2 (student : StudentV2) =
        printfn
            $"Student {student.Name} @ {student.FirstName};
            Mean : {student.MeanScore};
            Max : {student.MaxScore};
            Min : {student.MinScore}"
        
    let printSummaryV1 (student : Student) =
        printfn $"Student {student.Name}; Mean : {student.MeanScore}; Max : {student.MaxScore}; Min : {student.MinScore}"
    
    let printGroupSummary (surname : string) (students : StudentV2[]) =
        printfn $"{surname.ToUpperInvariant()}"
        
        students
        |> Array.sortBy (fun student -> student.MaxScore)
        |> Array.groupBy (fun student -> student.Name)
        |> Array.iter ( fun (key, studentArray) ->
            studentArray
            |> Array.iter (fun oneStudent -> printfn $"{oneStudent.FirstName} {oneStudent.StudentId} {oneStudent.MeanScore} {oneStudent.MinScore} {oneStudent.MaxScore}"))