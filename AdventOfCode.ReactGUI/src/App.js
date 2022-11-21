import './App.css';

const Day = (props) => {
    const { id } = props
    return (
        <button id="{id}" className="daysButton">{id}</button>
    )
}

function App() {
    return (
        <div className="App">
            <div className="container">
                <div className="left">
                    <p className="h1">Advent of Code 2022</p>
                    <div className='daysDiv'>
                        <Day id="1" />
                        <Day id="2" />
                        <Day id="3" />
                        <Day id="4" />
                        <Day id="5" />
                        <br></br>
                        <Day id="6" />
                        <Day id="7" />
                        <Day id="8" />
                        <Day id="9" />
                        <Day id="10" />
                    </div>
                </div>
                <div className="right"></div>
            </div>
        </div>
    );
}

export default App;
