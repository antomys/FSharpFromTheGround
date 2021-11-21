namespace CollectionFunctions.Common

module Quote =
    let quote symbol inputString =
        $"%c{symbol}%s{inputString}%c{symbol}"

    let toSingleQuote inputString =
        inputString
        |> quote '''

    let toDoubleQuote inputString =
        inputString
        |> quote '"'
        
    let toSingleQuoteV2 = quote '''

    let toDoubleQuoteV2 = quote '"'
