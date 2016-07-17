var webpack = require("webpack")
var path = require("path")

module.exports = [
    {
        entry: {  
            vendor: ["react", "react-dom"],
            index: "./scripts/src/controls.jsx"
        },
        output: {
            path: "scripts/dist",
            filename: "[name].js"
        },
        module: {
            loaders: [
                {
                    include: path.resolve(__dirname, "scripts/src"),
                    test: /\.jsx?/,
                    loader: "babel-loader",
                    query: {
                        presets: ["es2015", "react"]
                    }
                }
            ]
        },
        resolve: {
            extensions: ["", ".js", ".jsx"]
        },    
        plugins: [
            new webpack.optimize.CommonsChunkPlugin({
                name: "vendor",
                filename: "[name].js"
            })
        ]
    }
]