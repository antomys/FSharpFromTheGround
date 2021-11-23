namespace CollectionFunctions.Common

module Float=
    let tryFromString s =
        if s = "N/A" then
            Nothing
        else
             float s
             |> Something
   
    (*let fromStringOr50 inputString =
        let result = inputString |> tryFromString
        
        if result = Nothing then
            Optional.defaultValue 50.0
        else
            result*)

    let fromStringOr50V3 floatDefault inputString =
        let result = inputString |> tryFromString
        
        if result = Nothing then
            floatDefault
        else
            result
    
    let fromStringOr50V2 defaultValue inputString =
        inputString
        |> tryFromString
        |> Optional.defaultValue 50.0