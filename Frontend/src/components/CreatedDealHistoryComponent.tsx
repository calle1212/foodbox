import { Post } from "../types";
import { Link } from '@tanstack/react-router';


export default function CreatedDealHistoryComponent(post : Post){
  
    return (
    <tr>
        <td>{post.title}</td>
        <td>{post.description}</td>
        <td>{post.date}</td>
        <td> <Link to="/profile" search={{id: post.fulfillerClerkId}} className="btn"> Fulfiller profile</Link>{post.fulfillerClerkId}</td>
        <td>{post.reviewOnCreator && post.reviewOnCreator.rating}</td>
        <td>{post.isFulfilled ? <p className="text-green-600">Completed</p> : <button className="btn">Mark as completed</button>}</td>

    </tr>
    )
}
