import { Post } from "../types";
import { Link } from '@tanstack/react-router';


export default function FulfilledDealHistoryComponent(post : Post){
    //console.log(post.title);
        return (
        <tr>
            <td>{post.title}</td>
            <td>{post.description}</td>
            <td>{post.date}</td>
            <td> <Link to="/profile" search={{id: post.creatorClerkId}} className="btn"> Creator profile</Link></td>
            <td>{post.reviewOnCreator && post.reviewOnCreator.rating}</td>
            <td>{post.isFulfilled ? <p className="text-green-600">Completed</p> : <p>Not completed</p>}</td>
        </tr>
        )
    
}