enum OpCode {
    Game = 0x01
    Input = 0x02
    Flow = 0x03
    Data = 0x04
    Display = 0x05
    Sleep = 0x06
}

enum GameMode {
    start = 0x01
    stop = 0x02
    restart = 0x03
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