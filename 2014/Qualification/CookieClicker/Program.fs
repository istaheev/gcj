open System
open System.Collections.Generic

(*** helpers **)

let readString () = Console.ReadLine()

let parseIntegers (s : string) =
    s.Split(' ') |> Array.map int
    
let parseDoubles (s: string) =
    s.Split(' ') |> Array.map double

let readIntegers () = 
    readString () |> parseIntegers

let readDoubles () =
    readString () |> parseDoubles

let readInteger () = (readIntegers ()).[0]

// time to reach x with speed 'speed' without buying farms
let withoutFarms speed x = x / speed

// time to reach x if we build a farm 
let withFarm speed c f x = 
    c/speed +      // time to accumulate c cookies and buy a farm
    x/(speed + f)  // time to reach x with new speed after buying a farm

let rec calcTime time speed c f x =
    let withoutFarmsTime = withoutFarms speed x
    let withFarmsTime = withFarm speed c f x
    if withoutFarmsTime < withFarmsTime then
        time + withoutFarmsTime
    else
        calcTime (time + c/speed) (speed + f) c f x

[<EntryPoint>]
let main argv = 
    let numTests = readInteger()
    for i in [1..numTests] do
        let [| c; f; x |] = readDoubles ()
        printfn "Case #%d: %.7f" i (calcTime 0.0 2.0 c f x)
    0 // return an integer exit code
