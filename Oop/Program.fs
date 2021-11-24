namespace Oop

open System

type Person(name : string, favColor : string) =
    do
        if String.IsNullOrWhiteSpace(name) || String.IsNullOrWhiteSpace(favColor) then
            raise <| ArgumentException "Something is empty or null"

    let mutable _name = name
    let mutable _favColor = favColor
    (*member this.Person
        with get() = _name, _favColor
        and set (nm, fvCol) =
            if String.IsNullOrWhiteSpace(nm) || String.IsNullOrWhiteSpace(fvCol) then
                raise <| ArgumentException "Something is empty or null"
                _name <- nm
                _favColor <- fvCol*)
                
    member this.GetSomething() =
        printfn $"You are {_name} with favourite colour of {_favColor}"
            

type ConsolePrompt(message : string, maxTries : int) =
    do
        if String.IsNullOrWhiteSpace(message) then
            raise <| ArgumentNullException "message is null"
    let trimmedMessage = message.Trim()
    // Constructed body is optional
    let mutable tryCount = 0
    let mutable background = ConsoleColor.DarkYellow
    let mutable foreground = ConsoleColor.Black
    member this.GetValue() =
        tryCount <- tryCount + 1
        printf $"{trimmedMessage}"
        Console.ResetColor()
        let input = Console.ReadLine()
        if String.IsNullOrWhiteSpace(input) && tryCount < maxTries then
            if this.BeepOnError then
                Console.Beep()
            this.GetValue()
        else
            input
            
    member val BeepOnError = true
        with get, set
        
    member this.ColorScheme
        with get() =
            foreground, background
        and set(fg,bg) =
            if fg = bg then
                raise <| ArgumentException "Colors are equal"
            foreground <- fg
            background <- bg
            
            
module Program =

    [<EntryPoint>]
    let main argv =
        let namePerson = ConsolePrompt("Please enter name: ", 2)
        namePerson.BeepOnError <- false
        //namePerson.ColorScheme <- ConsoleColor.Cyan, ConsoleColor.Cyan
        let name = namePerson.GetValue()
        printfn $"Hello, {name}"
        
        let aa = Person (name, "Gray")
        
        aa.GetSomething()
        0