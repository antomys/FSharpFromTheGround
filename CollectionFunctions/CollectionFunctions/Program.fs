open System.IO
open System
let checkArgs (args:string[]) =
    args.Length <= 0

let doesFileExist filePath =
    let isExist = File.Exists filePath
    
    if isExist then
        printfn $"File {filePath} exists! Proceeding."
    else
        printfn $"File {filePath} not found"
    
    isExist

let getStudentsCount (studentFile:string[]) =
    (studentFile |> Array.length)
    
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

    $"{studentElements.[0]}:{studentElements.[1]}:mean:{mean}:min:{fst tupleStack}:max:{snd tupleStack}"


[<EntryPoint>]
let main args =
    if args |> checkArgs = false then
        printfn($"Processing file {args.[0]}")
        
        if doesFileExist args.[0] then
            let studentRows = args.[0]
                              |> File.ReadAllLines
                              |> Array.skip 1
                              
            printfn $"Student rows : {studentRows |> getStudentsCount}"
            printfn $"{getMeanScore studentRows.[0]}"
            printfn $"{getMeanScoreV2 studentRows.[0]}"
            printfn $"{getMeanScoreV3 studentRows.[0]}"
            0
        else
            0
    else
        printf("No args are assigned. Exit.")
        0