import React, {useState, useEffect}from 'react'
import "./SocialHome.css";
import { useNavigate } from "react-router-dom";
import axios from 'axios';
// import CommentBox from '../CommentBox';
import "react-responsive-carousel/lib/styles/carousel.min.css"; 
import 'bootstrap/dist/css/bootstrap.min.css';

// import news1 from "../../Images/emp1.jpg"
// import { Height } from '@mui/icons-material';

// https://api.unsplash.com/search/photos?page=1&query=office&client_id=pA-vUbXFxsmBgZ1C_-1TCMzhaVFsqQWuyHTUyaQ0Y4Y

const SocialHome = () => {
  const navigate = useNavigate();


//   const [index, setIndex] = useState(0);
//   const [news, setNews] = useState([])
  
//   useEffect(() =>{
//   axios.get('https://api.unsplash.com/search/photos?page=1&query=office&client_id=pA-vUbXFxsmBgZ1C_-1TCMzhaVFsqQWuyHTUyaQ0Y4Y')
//   .then(Response =>{
//     setNews(Response.data.results);
//   }).catch(error =>{
//     console.log(error);
//   });

//  },[] );


const [imageURL, setImageURL] = useState('');

useEffect(() => {
  axios
    .get('https://api.github.com/users')
    .then(response => {
      // Extract the avatar_url from the 0th index user
      const avatar_url = response.data[0].avatar_url;
      setImageURL(avatar_url);
    })
    .catch(error => {
      console.error('Error fetching data:', error);
    });
}, []);

  return (
  <div >

    <h5 className="socialHomehead"><span className=" " style={{padding:".5px",borderBottom:"4px solid rgb(233, 25, 133)"}}>Image Gallery</span></h5>
    <div className="SocialHome rounded shadow">

    <div className='SocialImageshow mt-0'> 
    {/* {news.map((item, index) => {
          return(

            <div className='SocialImageshow' key={index}>
                <img src={item.urls.small}  width="100%" height="100px" alt={item.name}/>
            </div>
          )})} */}

      {/* <img src={image.urls.small} alt="API Image" /> */}
      {imageURL && <img src={imageURL} className='mt-0 rounded' 
      // style={{objectFit:"cover"}} 
      alt="API Image" width="100%" height="300px" />}


    </div>




    </div>
    <div className="SocialHome2 rounded shadow">
          <div>
            <h6 className='socialh'>Album: Annual day celebration</h6>
          </div>
          <div className='socialp'>
            <p className=''>.....
            <button type="submit" 
                onClick={()=>navigate("/Social")}
            className='viewmore-btn-social mt-0'>View All</button>
            </p>
          </div>
    </div>
        </div>

  )
}

export default SocialHome