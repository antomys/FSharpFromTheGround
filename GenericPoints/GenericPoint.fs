namespace GenericPoints

type GenericPoint<'TValue> =
    {
        X : 'TValue
        Y : 'TValue
    }

module GenericPoint =
    
    let inline moveBy (dx : 'T) (dy : 'T) (point : GenericPoint<'T>) =
        {
            X = point.X + dx
            Y = point.Y + dy
        }
    
    let inline scaleBy (dx : 'T) (dy : 'T) (point : GenericPoint<'T>) =
        {
            X = point.X * dx
            Y = point.Y * dy
        }