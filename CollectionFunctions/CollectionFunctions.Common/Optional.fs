namespace CollectionFunctions.Common

type Optional<'T> =
    | Something of 'T
    | Nothing
    
module Optional =
    let defaultValue (defValue : 'T) (optional : Optional<'T>) =
        match optional with
        | Something something -> something
        | Nothing -> defValue
    
    let isSome (_ : 'T) (optional : Optional<'T>) =
        match optional with
        | Something _ -> true
        | Nothing -> false
        
        
    let get (_ : 'T) (tValue : Optional<'T>) =
         match tValue with
         | Something something -> something
         | Nothing -> tValue