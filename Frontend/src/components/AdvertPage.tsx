import { useQueryClient } from '@tanstack/react-query';
import { Post } from '../types';
import { useMatch } from '@tanstack/react-router';

export default function AdvertPage(){
    const { search } = useMatch("/deal");
    const qid= search.id;
    console.log(qid);

    const queryClient = useQueryClient();

    const data : Post[] = queryClient.getQueryData(["repoData"])
    const thisPost = data.find(p => p.id == qid);

    console.log(data);
    console.log(thisPost);
    return (
        <p>hej</p>
    )
}