namespace Currying

open CollectionFunctions.Common

module Program =
    
    let add a b =
        a+b

    let c = add 2 3

    let d = add 2

    let e = d 3

    [<EntryPoint>]
    let main _ =
        printfn $"c:{c}; d:{d}: e:{e}"
        let testString = "Testing string."
        printfn $"{Quote.toDoubleQuote testString}"
        printfn $"{Quote.toSingleQuote testString}"
        printfn $"{Quote.toDoubleQuoteV2 testString}"
        printfn $"{Quote.toSingleQuoteV2 testString}"
        0