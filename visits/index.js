const express = require("express")
const redis = require("redis")
const process = require("process")

const app = express()
const redisClient = redis.createClient({
    host: 'redis-server',
    port: 6379
})

redisClient.set("visits", 0)

app.get("/", (req, res) => {
    redisClient.get("visits", (err, visits) => {
        if (visits > 4)
            process.exit(1)
        res.send(`The number of visits is ${visits}`)
        redisClient.set("visits", parseInt(visits) + 1)
    })
})

app.listen(8081, () => {
    console.log("Listening on port 8081")
})