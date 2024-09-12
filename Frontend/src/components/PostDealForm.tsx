import { useUser } from "@clerk/clerk-react"
import { useMutation, useQueryClient } from "@tanstack/react-query"
import { useForm, SubmitHandler } from "react-hook-form"


type PostRequest = {
    title: string
    description: string
    payment: string
    location: string
    date: Date
    creatorClerkId: string | undefined
  }
  

export default function PostDealForm() {


    const queryClient = useQueryClient();
    const user = useUser();

    const postDealQuery  = useMutation({
        mutationFn: (postRequest : PostRequest) => {
            return fetch(`http://localhost:5063/api/Posts`, {
                method: "POST",
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(postRequest)
            })
        },
        onSuccess: () => queryClient.invalidateQueries({ queryKey: ["repoData"] }) 
    });




  const {
    register,
    handleSubmit,
    watch,
    formState: { errors },
  } = useForm<PostRequest>()
  const onSubmit: SubmitHandler<PostRequest> = (data) => {
    data.creatorClerkId = user.user?.id
    console.log(data)
    postDealQuery.mutate(data);
}

  console.log(watch("title")) // watch input value by passing the name of it

  return (
    /* "handleSubmit" will validate your inputs before invoking "onSubmit" */
    <form className="flex flex-col gap-5 p-3" onSubmit={handleSubmit(onSubmit)}>

      <label > Title: <input defaultValue="test" {...register("title", { required: true } )} /> </label>
      <label > Description: <input  defaultValue="test" {...register("description", { required: true })} /> </label>
      <label > Payment: <input defaultValue="250" {...register("payment", { required: true })} type="number"  /> </label>
      <label > Location: <input defaultValue="test" {...register("location", { required: true })} /> </label>
      <label > Date: <input defaultValue="2024-09-03" {...register("date", { required: true })} type="date" /> </label>

      {errors.title && <span>All fields are required</span>}

      <input className="btn btn-primary" type="submit" />
    </form>
  )
}