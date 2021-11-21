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