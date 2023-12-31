enum OpCode {
    Game = 0x01
    Input = 0x02
    Flow = 0x03
    Data = 0x04
    Display = 0x05
    Call = 0x07
}

enum GameMode {
    start = 0x01
    stop = 0x02
    restart = 0x03
}

enum DataOperation {
    Push = 0x01
    Pop = 0x02
    Dup = 0x03
}

enum InputDirection {
    left = 0x00
    right = 0x01
    drop = 0x02
}

macro input dir {
    db Input
    db dir
}

macro game mode {
    db Game
    db mode
}

macro start {
    game start
}

macro stop {
    game stop
}

macro display {
    db Display
}

macro sleep time {
    db Sleep
    db time
}

macro getCurrentTetromino {
    call 0
}

macro push value {
    db Data
    db Push
    db value
}

macro pop index {
    db Data
    db Pop
    db index
}

macro store value index {
    push value
    pop index
}

macro dup {
    db Data
    db Dup
}

macro pushTetrominoType x y {
    push x
    push y
    call 1
}

macro call funcIndex {
    db Call
    db funcIndex
}

macro sleep ms {
    push ms
    call 2
}