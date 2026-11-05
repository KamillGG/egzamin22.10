import { Form, FormCheck, FormControl, FormLabel } from 'react-bootstrap';
import { useState } from 'react';
export default function Main() {
    const [checked, setChecked] = useState(true);
  const [input, setInput] = useState({
    url: '',
    login: '',
    password: ''
  });
  const [data, setData] = useState({
    url: '',
    login: '',
    password: '',
    checked: true
  });
  const prepData = (input) => {
    const tempObj = {...input, checked: checked};
    setData(tempObj);
  }
    return(
<>
      <div>
        <h1>Menadżer haseł - wykonał 012345678910</h1>
        <Form>
        <label className="form-label" htmlFor="url" style={{width: '100%', textAlign: 'left'}}>Adres WWW: </label>
        <input className="form-control" id="url" value={input.url} onChange={(e) => setInput({...input, url: e.target.value})} placeholder="Adres strony WWW"/>

        <label className="form-label" style={{width: '100%', textAlign: 'left'}}>Login: </label>
        <input className="form-control" id="login" value={input.login} onChange={(e) => setInput({...input, login: e.target.value})} placeholder="Twój login"/>
        <div style={{display: 'flex', alignItems: 'center', gap: '0.5rem', justifyContent: 'flex-start', marginBottom: '0.5rem'}}>
        <input className="form-check-input" id="generatePassword" style={{margin: '0'}} type="checkbox" checked={checked} onChange={(e) => {setChecked(e.target.checked)}}/>
        <label className="form-check-label" htmlFor="generatePassword">Generuj hasło automatycznie</label>
        </div>

        <label className="form-label" htmlFor="password" style={{width: '100%', textAlign: 'left'}}>Hasło: </label>
        <input className="form-control" id="password" type="password" value={input.password} onChange={(e) => setInput({...input, password: e.target.value})} disabled={checked}/>

        <button className="btn btn-primary" onClick={(e) => {e.preventDefault(); prepData(input);}}>Zapisz</button>
        </Form>
      </div>
      <div>
        {data.url && (
            <div>
            <p style={{padding: '0.5rem', color:"blue"}} className="lead text-primary" >Adres: {data.url}</p>
            <p style={{padding: '0.5rem'}}>Login: {data.login}</p>
            <p style={{padding: '0.5rem'}}>{data.checked ? 'Hasło automatycznie generowane' : `hasło: ${data.password}`}</p>
          </div>
        )}
      </div>
        </>
)
}