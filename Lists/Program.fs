namespace Lists

open System
open System.Drawing

module Program =
    

    
    [<EntryPoint>]
    let main argv =
        let history = ColorHistory([Color.Indigo; Color.BlueViolet], 7)
        history.ListColors()
        history.RemoveLatest()
        history.ListColors()
        0 // return an integer exit code